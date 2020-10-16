import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMedicine } from '../../shared/models/medicine';
import { MedicineService } from '../medicine.service';

@Component({
  selector: 'app-medicine-item',
  templateUrl: './medicine-item.component.html',
  styleUrls: ['./medicine-item.component.scss']
})
export class MedicineItemComponent implements OnInit {
  @Input() medicine: IMedicine;

  constructor() {

  }

  ngOnInit(): void {
  }

}
