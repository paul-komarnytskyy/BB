import { Component, Input } from '@angular/core';
import { CharacteristicsService } from '../Services/characteristics.service';
import { FilterItemComponent } from '../Components/filter-item.component';

@Component({
    moduleId: module.id,
    selector: 'characteristics-filter',
    templateUrl: './characteristics-filter.html',
})

export class CharacteristicsFilterComponent {

    public currentFilter: any;
    public availableCharacteristics: any[];
    public selectedCategoryID: number;

    constructor(private characteristicsService: CharacteristicsService) {
        this.availableCharacteristics = [];//this.inputCharacteristic.availableCharacteristics;
        this.selectedCategoryID = 7;
        this.GetCharacteristicsForCategory(this.selectedCategoryID);
    }

    public GetCharacteristicsForCategory(categoryID: number) {
        this.characteristicsService.GetCharacteristics(categoryID)
            .map((response) => response.json())
            .subscribe((result) => 
            {
                this.availableCharacteristics.length = 0;
                for (var characteristic of result.chars) {
                    this.availableCharacteristics.push(characteristic);
                    console.log(characteristic);
                }
            });
    }
}
