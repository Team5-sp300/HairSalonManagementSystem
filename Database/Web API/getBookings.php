<?php
require_once(dirname(__FILE__).'/ConnectionInfo.php');

$connectionInfo = new ConnectionInfo();
$con=$connectionInfo->GetConnection();
// Check connection
if ($con->connect_error) {
    die("Connection failed: " . $con->connect_error);
}

$sql = "call getBooking";
$result = $con->query($sql);

$contacts = array();

if ($result->num_rows > 0) {

      while($row = mysqli_fetch_assoc($result)) {
          $contact = array("name" => $row['(SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID)'],"time" => $row['AppointmentTime']);

          //Add the contact to the contacts array
          array_push($contacts, $contact);


      }
    echo json_encode($contacts);
} else {
    echo "0 results";
}
$con->close();
?>
