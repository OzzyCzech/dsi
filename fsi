#!/bin/bash

# Rename images to YYYY-MM-DD_HH.MM.SS.[ext]

usage() { echo "Usage: $0 dir" 1>&2; exit 1; }

# show help
if [ "$#" -lt 1 ]
then
	usage
fi

if [ ! -d "$1"  ] ; then
	echo " is not a directory"
	usage
else
	from=${1}
fi


find -L "$from" -not -path '*/\.*' -type f | while read f
do

	filename=`mdls -name kMDItemContentCreationDate "$f" | cut -d' ' -f3,4 | tr ' ' '-' | tr ':' '.'`

	if [ "$filename" = '(none)' ] ; then
		filename=`$(date --date="$(GetFileInfo -d "$f")" +%Y-%m-%d-%H.%M.%S)`
	fi

 	# Get the extension in lower case
  ext=`echo ${f##*.} | tr '[:upper:]' '[:lower:]'`

	# Target filename add surfix
	if [[ -e $from/$filename.$ext ]] ; then
	    surfix=100001 # leading zeros --> 00001
	    while [[ -e "${from}/${filename}-${surfix:1}.${ext}" ]] ; do
	        let surfix++
	    done
	    filename="${filename}-${surfix:1}"
	fi

	# Rename file...
	mv -iv "${f}" "${from}/${filename}.${ext}"
done
