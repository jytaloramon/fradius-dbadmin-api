
```bash
docker run --name NAME_CONTAINER -e POSTGRES_USER=root -e POSTGRES_PASSWORD=1234 -e POSTGRES_DB=db_fradius -v PATH_DATAPSQL:/var/lib/postgresql/data postgres
```

```bash
docker build -t fradiusdbadmin/devapi -f Dockerfile.dotnet ./
```

```bash
docker run --name NAME_CONTAINER -d -v PATH_PROJECT:/app -it fradiusdbadmin/devapi /bin/sh
```