
## Organize images

### Organize images by years/months

```
exiftool -d "%Y/%m/%Y-%m-%d %H.%M.%S%%-c.%%le" "-filename<CreateDate" -r ./Photos
```
### Download RAW files from SD card to current folder

```
exiftool -d "%Y/%m/%Y-%m-%d %H.%M.%S%%-c.%%le" "-filename<CreateDate" --ext cr2 -r /Volumes/SD
```

### Move all Olympus images to directory Olympus

```
exiftool -r '-directory=Olympus' -if '$make eq "OLYMPUS CORPORATION"' .
```

### Rename files to datestamp

*Filename looks like 2014-01-01 12:00:00.jpg and will append -NUM if DateTimeOriginal is the same for multiple files*

```
exiftool '-FileName<DateTimeOriginal' -d "%Y-%m-%d %H.%M.%S%%-c.%%e" .  
```  

## Date & time

### Find images in a directory that don't have a DateTimeOriginal ###

```
exiftool -filename -filemodifydate -createdate -r -if '(not $datetimeoriginal) and $filetype eq "JPEG"' .
```    

### Update any photo that doesn't have DateTimeOriginal to have it based on file modify date

```
exiftool '-datetimeoriginal<filemodifydate' -if '(not $datetimeoriginal or ($datetimeoriginal eq "0000:00:00 00:00:00")) and ($filetype eq "JPEG")' .
```

### Set date by filename

```
exiftool "-alldates<filename" $@
```

## All metadata

Remove all metadata of a image file:

```
exiftool -all= -overwrite_original photo.jpg
```

Remove all metadata of all `*.jpg` files in current directory:

```
exiftool -all= -overwrite_original -ext *.jpg
```

## GPS

Strip all metadata except for location (GPS):

```
exiftool -all= -tagsfromfile @ -gps:all *.jpg
```
Remove all GPS metadata of `*.jpg` files in current directory:

```
exiftool -gps:all= *.jpg
```

## JSON

Outputs a grouped collection of records as JSON in a directory:

```
exiftool -json -g /path > collectionprofile.json
```

# Extra

### Create KML from geotagged photos

```
DESKTOP=$HOME/Desktop
cat $DESKTOP/kml-start.fmt > out.kml
exiftool -n -r -q -p $DESKTOP/kml-placemark.fmt . >> out.kml
cat $DESKTOP/kml-end.fmt >> out.kml
```
### Create CSV of Geo Information

```
exiftool -csv -filename -imagesize -gps:GPSLatitude -gps:GPSLongitude ./ > long.csv
```


## Links

* https://github.com/kurkale6ka/help/blob/559f91df84cb06c989f63219e928f1a0b23163fc/exiftool.txt
* http://libre-software.net/edit-metadata-exiftool/
* http://ninedegreesbelow.com/photography/exiftool-commands.html#rename
* https://linux.die.net/man/1/exiftool
