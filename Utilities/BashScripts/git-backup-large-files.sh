# Backup the media files in "git-backup-large-files.txt"
# The "sed" command removes lines starting with "#"

savemedia="/c/tmp/delete-media/"

cat delete-media.txt | sed '/^#/d' | while read sha size path; do
    folder=`echo $path | sed 's#\(.*\)/.*#\1#'`
    # echo "$sha : $size, $path"
    # echo "$folder"
    save_folder="$savemedia$folder"
    echo $save_folder
    mkdir -p "$save_folder"
    save_path="$savemedia$path"
    echo $save_path
    echo
    git cat-file blob $sha >"$save_path"
done


# DELETE="{*0.mp4,*4.mp4,*s.mp4,*x.mp4,*).mp4,*o.mp4,*5.mp4,*9.mp4,*.flac}"
