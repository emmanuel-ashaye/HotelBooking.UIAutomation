FROM emmanuelashaye/dotnet-core-test-runner AS build
WORKDIR /src
COPY . .
WORKDIR "/src/HotelBooking.UITests"
RUN dotnet add HotelBooking.UITests.csproj package NunitXml.TestLogger && \
    dotnet build "HotelBooking.UITests.csproj" && \
    echo "mono /extent.0.0.3/tools/extent.exe -d TestResults -o TestResults/ --merge" > CreateExtentReport.sh

ENTRYPOINT ["tail", "-f", "/dev/null"]