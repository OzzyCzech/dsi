# Picture structure helpers

List of useful exif shortcuts

# Install

```
curl https://raw.githubusercontent.com/OzzyCzech/picture-structure-helpers/master/.images > ~/.images && source ~/.images
```

# Usage

##  Download tools

Download images/raw/videos from `/Volumes/SD` to current directory

```
download-images /Volumes/SD
download-videos /Volumes/SD
download-raws /Volumes/SD
```

## Rename only

```
exif-rename-only .
```

## Add exif comment

```
exif-add-comment "Comment text" file.jpg
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
exif-to-json *.jpg > output.json
```

# Useful commands

## Empty directories

```
find /Volumes/SD -type d -empty -print          # find
find /Volumes/SD -type d -empty -delete         # delete
```

## Hidden files

```
find /Volumes/SD -name ".*"                     # find
find /Volumes/SD -name ".*" -exec rm -rf {} \;  # delete
```

## Renaming files in a folder to sequential numbers

```
rename --counter-format 00001 --lower-case --keep-extension --expr='$_ = "$N" if @EXT' *
```

# Syncing images from one folder to another

Copy **all missing files** from source directory to destination directory:

```
rsync -ain [source dir] [dest dir]              # -n is dry run
```

# Backup

* [Amazon Cloud Drive](https://www.amazon.com/clouddrive) - cheap unlimited image/file storage
* [Flickr](https://www.flickr.com/) - 1TB free image storage
* [Lima](https://meetlima.com/) - Private Personal Cloud

# Tools & Apps

* [Gemini 2](https://macpaw.com/store/gemini) - duplicity finder
* [rclone](https://rclone.org/) - command line program to sync files and directories to and from cloud storage providers

# Links

* [exiftool Application Documentation](http://www.sno.phy.queensu.ca/~phil/exiftool/exiftool_pod.html)
* [ExifTool Command-Line Examples](http://owl.phy.queensu.ca/~phil/exiftool/examples.html)
* [rsync man page](http://linuxcommand.org/man_pages/rsync1.html)
* [PhotoExporter](https://github.com/abentele/PhotosExporter)