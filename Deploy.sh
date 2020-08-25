git pull
docker container stop akaucore
docker container rm akaucore
docker build -t batlefroc/akaucore .
docker run -p 8081:80 -d --network weebo --name akaucore batlefroc/akaucore 
docker network connect weebo akaucore
sleep 2s
docker logs akaucore

git_message=$(git log --oneline -n 1)
dock_message=$(docker logs akaucore)
messagefinal='"GIT: '$git_message"\nDocker: "$dock_message'"'
export WEBHOOK_URL="https://discordapp.com/api/webhooks/735175356054765618/MdOM3hDJPPEi1HBnCDJWhPQNK78-dOShV_mbu2dR4PfQfUZd_m0T3AMff670UMgqKCr4"

curl -X POST \
    -H "Content-Type: application/json" \
    -d "{
        \"embeds\":[
        {
            \"title\":\"Update du core du projet\",
            \"color\":\"707070\",
             \"url\":\"https://akaucore.weebo.fr/\",
             \"description\":$messagefinal
        }
    ]}" \
    $WEBHOOK_URL