FROM ubuntu-mono-nuget

RUN echo "mono /extent.0.0.3/tools/extent.exe -d /TestResults -o /TestResults/ --merge" > CreateExtentReport.sh
RUN echo "mono /ReportUnit.1.2.1/tools/ReportUnit.exe 'TestResults' 'TestResults'" > CreateReportUnit.sh

RUN nuget update -self
RUN nuget install Extent
Run nuget install ReportUnit

ENTRYPOINT ["tail", "-f", "/dev/null"]