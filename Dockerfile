FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["HotelBooking.UITests/HotelBooking.UITests.csproj", "HotelBooking.UITests/"]
COPY ["UIFramework/UIFramework.csproj", "UIFramework/"] 
RUN dotnet restore "HotelBooking.UITests/HotelBooking.UITests.csproj"
COPY . .
WORKDIR "/src/HotelBooking.UITests"
RUN dotnet add HotelBooking.UITests.csproj package NunitXml.TestLogger
RUN dotnet build "HotelBooking.UITests.csproj"

ENTRYPOINT ["tail", "-f", "/dev/null"]