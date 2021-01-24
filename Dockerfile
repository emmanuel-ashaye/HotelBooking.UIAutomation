FROM emmanuelashaye/dotnet-core-test-runner AS build
WORKDIR /src
COPY ["HotelBooking.UITests/HotelBooking.UITests.csproj", "HotelBooking.UITests/"]
COPY ["UIFramework/UIFramework.csproj", "UIFramework/"] 
RUN dotnet restore "HotelBooking.UITests/HotelBooking.UITests.csproj"
COPY . .
WORKDIR "/src/HotelBooking.UITests"
RUN dotnet add HotelBooking.UITests.csproj package NunitXml.TestLogger && \
    dotnet build "HotelBooking.UITests.csproj" && \
    echo "mono /extent.0.0.3/tools/extent.exe -d TestResults -o TestResults/ --merge" > CreateExtentReport.sh

ENTRYPOINT ["tail", "-f", "/dev/null"]