import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MedicineComponent } from './medicine.component';
import { MedicineItemComponent } from './medicine-item/medicine-item.component';
import { SharedModule } from '../shared/shared.module';
import { MedicineDetailsComponent } from './medicine-details/medicine-details.component';
import { MedicineRoutingModule } from './medicine-routing.module';
import { EditMedicineComponent } from './edit-medicine/edit-medicine.component';

import { PostMedicineComponent } from './post-medicine/post-medicine.component';

@NgModule({
  declarations: [
    MedicineComponent,
    MedicineItemComponent,
    MedicineDetailsComponent,
    EditMedicineComponent,
    PostMedicineComponent],
  imports: [
    CommonModule,
    SharedModule,
    MedicineRoutingModule
  ]
})
export class MedicineModule { }
