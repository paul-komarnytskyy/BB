import { Component } from '@angular/core';
import { CharacteristicsService } from '../Services/characteristics.service';

@Component({
    moduleId: module.id,
    selector: 'filter-item',
    templateUrl: './filter-item.html',
})

export class FilterItemComponent {
    public currentFilter: any;
    public availableCharacteristics: any[];
    constructor(private characteristicsService: CharacteristicsService) {
    }

    public GetCharacteristicsForCategory(categoryID: number) {
        this.characteristicsService.GetCharacteristics(categoryID)
            .map((response) => response.json())
            .subscribe((characteristics) => {
                this.availableCharacteristics = [];
                for (var characteristic of characteristics) {
                    this.availableCharacteristics.push(characteristic);
                }
            });
    }
}
