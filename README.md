# dsi - directory structure images

Script that move or copy recursively files containing creation dates to a **year/month** directory structure

New files are directly moved if it does exists if it exists, `filename_MD5` is created to allow further checks
Logs are in `copied.log`, `already.log` and `error.log`

* . indicates move or copy
* + indicates move or copy with MD5
* _ indicates already there

All error files are copied in 'unknown' folder that must be checked.

## Usage

```bash 
./dsi dir [--to output dir] [--cp]
```

* `--to [dirname]` target directory
* `--cp` copy instead of move

## Examples

Reorganize folder 2017 with images to structure 2016/[month]/file

```bash
./dsi ./2017 --to .
```

Create Backup of all images in ./Pictures to externall hard drive Backup

```bash
./dsi ./Pictures --to /Volumes/Backup --cp
```

Originaly based on https://github.com/ArnaudFabre/dcopy
