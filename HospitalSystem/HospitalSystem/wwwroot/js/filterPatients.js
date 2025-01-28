document.getElementById("patientFilter").addEventListener("change", function () {
    var selectedPatient = this.value.toLowerCase();
    var rows = document.querySelectorAll("#appointmentsTable tbody tr");

    rows.forEach(row => {
        var patientCell = row.querySelector(".patient-name");
        var patientName = patientCell.textContent.toLowerCase();

        if (!selectedPatient || patientName.includes(selectedPatient)) {
            row.style.display = "";
        } else {
            row.style.display = "none";
        }
    });
});