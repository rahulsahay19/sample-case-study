import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMedicine } from 'src/app/shared/models/medicine';
import { MedicineService } from '../medicine.service';

@Component({
  selector: 'app-medicine-details',
  templateUrl: './medicine-details.component.html',
  styleUrls: ['./medicine-details.component.scss']
})
export class MedicineDetailsComponent implements OnInit {
  medicine: IMedicine;
  constructor(private medicineService: MedicineService, private activatedRoute: ActivatedRoute, private router: Router) {

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
}
