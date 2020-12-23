SET PACKAGE_VERSION="1.0.0"

dotnet pack SoilMechanicsLibrary/SoilMechanicsLibrary.csproj -c release --no-build --output ./nuget /p:PackageVersion=%PACKAGE_VERSION%