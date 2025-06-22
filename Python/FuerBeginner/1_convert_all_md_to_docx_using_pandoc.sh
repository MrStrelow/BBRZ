# use git bash for this.

#!/bin/bash

# This script finds all Markdown (.md) files in subdirectories whose names
# match the regex L0[4-9].+, then converts them to .docx using pandoc.

echo "Starting conversion process..."
echo "---------------------------------"

find . -regextype posix-extended -regex './L0[4-9].+/.*(angabe|solution)\.md' -print0 | while IFS= read -r -d $'\0' file; do
  
  # Get the directory name, filename with extension, and filename without extension
  dir_path=$(dirname "$file")
  echo $dir_path

  base_name_with_ext=$(basename "$file")
  base_name_no_ext="${base_name_with_ext%.md}"
  
  # Construct the full path for the output file
  output_file="$dir_path/$base_name_no_ext-from-md.docx"

  echo "Found:       $file"
  echo "Converting to: $output_file"
  
  # Run the pandoc conversion with the --resource-path flag added
  pandoc -s "$file" -o "$output_file" --reference-doc=easy4me-template.docx --resource-path="$dir_path"
  
  # Check if pandoc command was successful
  if [ $? -eq 0 ]; then
    echo "SUCCESS: Conversion complete."
  else
    echo "ERROR: Pandoc failed to convert $file."
  fi
  
  echo "---------------------------------"

done

echo "All Markdown files have been processed."