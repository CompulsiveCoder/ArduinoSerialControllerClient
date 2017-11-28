
docker run -i -v /var/run/docker.sock:/var/run/docker.sock -v $PWD:/ArduinoSerialControllerClient compulsivecoder/ubuntu-arm-mono /bin/bash -c "rsync -avzh /ArduinoSerialControllerClient/ /project && cd /project && sh prepare.sh && sh init.sh && sh build.sh"
