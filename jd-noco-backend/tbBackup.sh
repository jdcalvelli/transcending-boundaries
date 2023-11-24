#! /bin/sh

# get the current date in year month day format
# whitespace matters
currentDate=$(date +%Y%m%d)

# cd to the right location to save the backup
cd /root/tb-backups

# first commit the docker container to an image
# hard coded the container id, will have to be changed later
docker commit 9954d05a43cb un/tb:$currentDate

# then save the image
docker image save -o un_tb_$currentDate.tar un/tb:$currentDate