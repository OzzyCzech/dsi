
### Find images in a directory that don't have a DateTimeOriginal ###

    exiftool -filename -filemodifydate -createdate -r -if '(not $datetimeoriginal) and $filetype eq "JPEG"' .

# Organize images by years/months

    exiftool -d "%Y/%m/%Y-%m-%D %H.%M.%S%%-c.%%le" "-filename<CreateDate" -r ./Photos

# Download RAW files from SD card to current folder

    exiftool -d "%Y/%m/%Y-%m-%D %H.%M.%S%%-c.%%le" "-filename<CreateDate" --ext cr2 -r /Volumes/SD

# Rename files to datestamp

*Filename looks like 2014-01-01 12:00:00.jpg and will append -NUM if DateTimeOriginal is the same for multiple files*

    exiftool '-FileName<DateTimeOriginal' -d "%Y-%m-%d %H.%M.%S%%-c.%%e" .  
    
# Update any photo that doesn't have DateTimeOriginal to have it based on file modify date

    exiftool '-datetimeoriginal<filemodifydate' -if '(not $datetimeoriginal or ($datetimeoriginal eq "0000:00:00 00:00:00")) and ($filetype eq "JPEG")' .
    
# Extra

## Create KML from geotagged photos

	DESKTOP=$HOME/Desktop
	cat $DESKTOP/kml-start.fmt > out.kml
	exiftool -n -r -q -p $DESKTOP/kml-placemark.fmt . >> out.kml
	cat $DESKTOP/kml-end.fmt >> out.kml

# Create CSV of Geo Information

	exiftool -csv -filename -imagesize -gps:GPSLatitude -gps:GPSLongitude ./ > long.csv
