# use git bash for this.

#!/bin/bash

# This script finds all Markdown (.md) files in subdirectories whose names
# match the regex L0[4-9].+, then converts them to .docx using pandoc.

echo "Starting conversion process..."
echo "---------------------------------"

# Use 'find' with the -regex option to filter directories.
# The regex matches any path that is inside a directory matching your pattern.
# The -print0 and 'while read -r -d $' are a robust way to handle filenames
# with spaces or special characters.
find . -regextype posix-extended -regex './L0[4-9].+/.*\.md' -print0 | while IFS= read -r -d $'\0' file; do
  
  # Get the directory name, filename with extension, and filename without extension
  dir_path=$(dirname "$file")

  base_name_with_ext=$(basename "$file")
  base_name_no_ext="${base_name_with_ext%.md}"
  
  # Construct the full path for the output file
  output_file="$dir_path/$base_name_no_ext.docx"

  echo "Found:       $file"
  echo "Converting to: $output_file"
  
  # Run the pandoc conversion
  pandoc -s "$file" -o "$output_file" --reference-doc=easy4me-template.docx
  
  # Check if pandoc command was successful
  if [ $? -eq 0 ]; then
    echo "SUCCESS: Conversion complete."
  else
    echo "ERROR: Pandoc failed to convert $file."
  fi
  
  echo "---------------------------------"

done

echo "All Markdown files have been processed."