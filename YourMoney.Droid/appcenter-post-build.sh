set -e

echo "Found NUnit test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*Core.Tests.*\.csproj' -exec echo {} \;
echo
echo "Building NUnit test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*Core.Tests.*\.csproj' -exec msbuild {} \;
echo
echo "Compiled projects to run NUnit tests:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*bin.*Core.Tests.*\.dll' -exec echo {} \;
echo
echo "Running NUnit tests:"
#find $APPCENTER_SOURCE_DIRECTORY -regex '.*bin.*Core.Tests.*\.dll' -exec nunit3-console {} \;
testProj=$( find $APPCENTER_SOURCE_DIRECTORY -regex '.*bin.*Core.Tests.*\.dll' ) \;
nunit3-console $testProj
echo
echo "NUnit tests result:"
find . -name 'TestResult.xml' -exec cat {} ';' -exec cp {} $APPCENTER_OUTPUT_DIRECTORY \;