# Picture structure helpers

List of useful exif shortcuts

# Install

```
curl https://raw.githubusercontent.com/OzzyCzech/picture-structure-helpers/master/.images > ~/.images && source ~/.images
```

# Usage

##  Download tools

Download images/raw/videos from `/Volumes/SD` to current directory

```bash
download-images /Volumes/SD
download-videos /Volumes/SD
download-raws /Volumes/SD
```

## Add exif comment

```
exif-add-comment "Comment" file.jpg
exif-add-comment "Comment text" ./2017/01/24/*  # all images in directory
```

## Remove all exif information

```
exif-remove-all file.jpg
exif-remove-all -ext jpg .
```

## Remove GPS exif information

```
exif-remove-gps file.jpg
exif-remove-gps -ext jpg .
```

### Generate thumbnail

```
exif-thumbnail image.jpg > image-thumbnail.jpg
```

### Export exif to json

```
exif-to-json image.jpg > image-exif.json
```

# Useful commands

## Find empty directories

```
find . -type d -empty -print
```

## Delete empty directories

```
find . -type d -empty -delete
```

## Show all hidden files

```
find . -name ".*"
```

## Remove all hidden files

```
find . -name ".*" -exec rm -rf {} \;
```

# Links

* [exiftool Application Documentation](http://www.sno.phy.queensu.ca/~phil/exiftool/exiftool_pod.html)
* [ExifTool Command-Line Examples](http://owl.phy.queensu.ca/~phil/exiftool/examples.html)
