#!/bin/bash

# Rename images to YYYY-MM-DD HH.MM.SS.[ext]

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

	ts=`date`
	filename=`mdls -name kMDItemContentCreationDate "$f" | cut -d' ' -f3,4 | tr ':' '.'`

	if [ "$filename" = '(null)' ] ; then
		filename=`$(date --date="$(GetFileInfo -d "$f")" +%Y-%m-%d %H.%M.%S)`
	fi

 	# Get the extension in lower case
  	ext=`echo ${f##*.} | tr '[:upper:]' '[:lower:]'`
	todir=$(dirname "${f}")

	# Target filename add surfix
	if [[ -e $todir/$filename.$ext ]] ; then
	    surfix=100001 # leading zeros --> 00001
	    while [[ -e "${todir}/${filename}-${surfix:1}.${ext}" ]] ; do
	        let surfix++
	    done
	    filename="${filename}-${surfix:1}"
	fi

	# Rename file...
	mv -iv "${f}" "${todir}/${filename}.${ext}"
	echo "[$ts] $f > ${todir}/${filename}.${ext}" >> renamed.log
	echo -n .
done
