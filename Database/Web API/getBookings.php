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
          $contact = array("id" => $row['BookingID'],"cusomter" => $row['(SELECT CustomerName FROM Customer WHERE Booking.CustomerID=Customer.CustomerID)'],"employee" => $row['(SELECT EmployeeFname FROM Employee WHERE Booking.EmployeeUsername=Employee.Username)'],"date" => $row['DATE_FORMAT(AppointmentDate,"%d/%m")'],"time" => $row['AppointmentTime'],"service" => $row['(SELECT ServiceDescription FROM Service WHERE Booking.ServiceID = Service.ServiceID)']);

          //Add the contact to the contacts array
          array_push($contacts, $contact);


      }
    echo json_encode($contacts);
} else {
    echo "0 results";
}
$con->close();
?>
