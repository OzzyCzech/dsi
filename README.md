# Picture structure helpers

List of useful exif shortcuts


## Add comment

```
./add-comment 'comment text' ./Picture000.jpg
./add-comment 'Christmas party' ./2017/01/24/* # all images in directory
```

## Remove all EXIF

```
./clean-all-exif -ext
```

## Find empty directories

```
find . -type d -empty -print
```

## Delete empty directories

```
find . -type d -empty -delete
```
