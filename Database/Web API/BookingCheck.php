<?php
require_once(dirname(__FILE__) . '/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con = $connectionInfo->GetConnection();
if (isset($_POST['efname'])&& isset($_POST['elname'])&& isset($_POST['adate'])&& isset($_POST['atime'])&& isset($_POST['service'])) {
    //Get the POST variables
    $efname = $_POST['efname'];
    $elname = $_POST['elname'];
    $adate = $_POST['adate'];
    $atime = $_POST['atime'];
    $service = $_POST['service'];

if ($con->connect_error) {
    die("Connection failed: " . $con->connect_error);
}


 $sql = "call bookingCheck('$efname', '$elname','$adate','$atime','$service')";
//$sql = "SELECT COUNT(*) FROM BOOKING";
$result = $con->query($sql);

$contacts = array();

while ($row = mysqli_fetch_assoc($result)) {
    $contact = array("count" => $row['COUNT(*)']);

    array_push($contacts, $contact);

}
echo json_encode($contact);
$con->close();
}
?>
