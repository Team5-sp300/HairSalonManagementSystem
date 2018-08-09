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
          $contact = array("cusomter" => $row['(SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID)'],"employee" => $row['(SELECT EmployeeName FROM Employee WHERE Booking.EmployeeID=Employee.EmployeeID)'],"date" => $row['AppointmentDate'],"time" => $row['AppointmentTime']);

          //Add the contact to the contacts array
          array_push($contacts, $contact);


      }
    echo json_encode($contacts);
} else {
    echo "0 results";
}
$con->close();
?>
