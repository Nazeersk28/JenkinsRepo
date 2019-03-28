aws ecs create-cluster --cluster-name ${CLUSTER_NAME} --region ap-south-1

aws ecs register-task-definition --cli-input-json file://fargate-task.json --region ap-south-1

aws ecs list-task-definitions --region ap-south-1

aws ecs create-service --region ap-south-1 --cluster ${CLUSTER_NAME} --service-name fargate-service --task-definition cgiprofessionalnetcoreservices --desired-count 1 --launch-type "FARGATE" --network-configuration "awsvpcConfiguration={subnets=[subnet-0008f92ed5887c067],securityGroups=[sg-08fb93c325f5ae436],assignPublicIp=ENABLED}"

