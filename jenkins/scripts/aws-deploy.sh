aws ecs create-cluster --cluster-name fargate-cluster

aws ecs register-task-definition --cli-input-json file://fargate-task.json

aws ecs list-task-definitions

aws ecs create-service --cluster fargate-cluster --service-name fargate-service --task-definition cgiprofessionalnetcoreservices --desired-count 1 --launch-type "FARGATE" --network-configuration "awsvpcConfiguration={subnets=[subnet-0008f92ed5887c067],securityGroups=[sg-08fb93c325f5ae436],assignPublicIp=ENABLED}"

