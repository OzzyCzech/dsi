# Picture structure helpers

List of useful exif shortcuts

# Install

```
source .images
```


## Add comment

```
exif-add-comment "Comment" file.jpg
exif-add-comment "Comment text" ./2017/01/24/*  # all images in directory
```

## Remove all EXIF

```
exif-remove-all file.jpg
```

```
exif-to-json file.jpg
```


## Find empty directories

```
find . -type d -empty -print
```

## Delete empty directories

```
find . -type d -empty -delete
```
