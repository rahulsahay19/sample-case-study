import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMedicine } from 'src/app/shared/models/medicine';
import { MedicineService } from '../medicine.service';

@Component({
  selector: 'app-edit-medicine',
  templateUrl: './edit-medicine.component.html',
  styleUrls: ['./edit-medicine.component.scss']
})
export class EditMedicineComponent implements OnInit {
  medicine: IMedicine;
  id: number;
  constructor(private activatedRoute: ActivatedRoute, private medicineService: MedicineService, private router: Router) {
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.loadMedicine();
  }

  loadMedicine() {
    this.medicineService.getMedicine(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(med => {
        this.medicine = med;
        console.log(this.medicine);
      }, error => {
        console.log(`An error occured while fetching medicine:- ${error}`);
      });
  }

  editMedicine() {
    var date = new Date(this.medicine.expiryDate);
    console.log(date);
    var today = new Date();
    console.log(new Date(today.getFullYear(), today.getMonth(), today.getDate() + 30));
    if (date < (new Date(today.getFullYear(), today.getMonth(), today.getDate() + 30))) {
      console.log('Medicine less than 30 days cannot be posted');
    } else {
      this.medicineService.editMedicine(this.medicine).subscribe(() => {
        console.log('Medicine updated successfully');
      }, error => {
        console.log(error);
      });
    }

  }

  onDelete() {
    this.medicineService.deleteMedicine(this.id).subscribe(() => {
      console.log('Medicine deleted successfully');
      this.router.navigate(['/medicine']);
    }, error => {
      console.log(error);
    });
  }
}
