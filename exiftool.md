# Organize images by years/months

```bash
exiftool -d "%Y/%m/%Y-%m-%D %H.%M.%S%%-c.%%le" "-filename<CreateDate" -r ./Photos
```

# Download RAW files from SD card to current folder

```bash
exiftool -d "%Y/%m/%Y-%m-%D %H.%M.%S%%-c.%%le" "-filename<CreateDate" --ext cr2 -r /Volumes/SD
```
