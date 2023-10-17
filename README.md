# egen

![license](https://img.shields.io/badge/license-BSD-brightgreen.svg)
![version](https://img.shields.io/badge/version-0.0.2-lightgrey.svg)
![build](https://img.shields.io/github/actions/workflow/status/cavoq/egen/workflow.yml)

CLI Tool for email analysis and generation.

## Developer Notes:

You need to install **Cake** to run the build script. You can install it with the following command:

```bash
dotnet tool install -g Cake.Tool --version 3.1.0
```

## Running the build script

To run the build script, run the following command:

```bash
dotnet cake --target <target>
```

## Available targets

- **Default** - Runs the CLI tool.
- **Build** - Builds the CLI tool.
- **Run** - Runs the CLI tool.
- **Clean** - Cleans build.
- **Test** - Runs tests.
- **docker-build** - Builds the docker image.
- **docker-run** - Shells into the docker container.
