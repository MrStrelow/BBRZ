import glob
import re
from pathlib import Path
from docx import Document
from docx.shared import Inches
from docx.opc.constants import RELATIONSHIP_TYPE
import os
import time

def change_hyperlinks_in_docx(document, document_path_string, server_base_link="https://www.e4m.info/downloads/python/Turtle/"):
    """
    Finds and updates hyperlinks in a .docx file based on a specified pattern.

    Args:
        document: The python-docx Document object.
        document_path_string: path of the document.
        server_base_link (str): The base URL for the new link.
    """

    pattern_for_L0 = r"L0.*\.md"
    pattern_for_relative_path = r".*\.\.\/.*\.md"

    try:
        rels = document.part.rels
        links_changed = 0
        for rel_id in rels:
            rel = rels[rel_id]
            if rel.reltype == RELATIONSHIP_TYPE.HYPERLINK:
                current_link = rel.target_ref
                path_clean = current_link.split('#')[0]
                path_clean_docx = path_clean.replace("md", "docx")

                # Check if the link matches the pattern to be replaced
                L0_pattern_search = re.search(pattern_for_L0, path_clean)
                relative_pattern_search = re.search(pattern_for_relative_path, path_clean)
                
                if L0_pattern_search or relative_pattern_search:
                    if relative_pattern_search:
                        document_path = Path(document_path_string)
                        repetitions = path_clean.count("../") + 1 # +1 weil immer files angegeben werden

                        link_main_part = path_clean.replace("../", "")
                        for _ in range(repetitions):
                            document_path = document_path.parent
                        
                        path = os.path.join(str(document_path), link_main_part)
                        match = re.search(r"L0", path)
                        paths = [path[:match.start()], path[match.start():]] if match else [path]
                        path_clean = paths[1]
                        path_clean_docx = path_clean.replace("md", "docx")

                    path_to_server = os.path.join(server_base_link, path_clean_docx)
                else:
                    print(f"\033[31mWARNING -> link: {current_link} is not intended to change\033[0m")
                    continue

                # Update the relationship target
                rel._target = path_to_server
                links_changed += 1
                print(f"  -> Changed link: {current_link} -> {path_to_server}")

        if links_changed == 0:
            print("  -> No matching hyperlinks found to change.")
            
    except Exception as e:
        print(f"  [ERROR] An unexpected error occurred while changing hyperlinks: {e}")


def process_docx_file(docx_path):
    """
    Orchestrates the processing of a single DOCX file for images and hyperlinks.
    """
    print(f"\n-> Processing '{docx_path}'")
    try:
        document = Document(docx_path)
    except Exception as e:
        print(f"  [ERROR] Could not open file {docx_path}. Skipping. Error: {e}")
        return

    # --- 1. Process and Update Hyperlinks ---
    change_hyperlinks_in_docx(document, docx_path)

    # --- 2. Save the Final Document ---
    final_path = docx_path.replace('-gifs-added', '')
    try:
        document.save(final_path)
        print(f"-> Saved final version as '{os.path.basename(final_path)}'")
    except Exception as e:
        print(f"  [ERROR] Could not save the final document {final_path}. Error: {e}")


if __name__ == '__main__':
    # --- Configuration ---
    DELETE_INPUT = True # Set to False to keep the original '-gifs-added.docx' files

    if DELETE_INPUT:
        print("\033[31mWILL DELETE input docx files after processing.\033[0m")
        print("Starting in 3 seconds...")
        time.sleep(3)

    print("\n--- Starting Post-Processing of DOCX Files ---")
    
    # Search for files in the current directory and all subdirectories
    search_pattern = './**/*-gifs-added.docx'
    
    files_found = glob.glob(search_pattern, recursive=True)

    if not files_found:
        print("No '...-gifs-added.docx' files found to process.")
    else:
        print(f"Found {len(files_found)} files to process.")
        for docx_file in files_found:
            process_docx_file(docx_file)

            if DELETE_INPUT:
                try:
                    os.remove(docx_file)
                    print(f"-> Deleted temporary file '{os.path.basename(docx_file)}'")
                except OSError as e:
                    print(f"  [ERROR] Could not delete temporary file {docx_file}. Error: {e}")

    print("\n--- Post-Processing Complete ---")
