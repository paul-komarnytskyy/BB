import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'filter-item',
    templateUrl: './filter-item.html',
})

export class FilterItemComponent {
    public availableOptions: any[];
    public selectedOptions: any[];

    constructor() {
        this.availableOptions
        this.selectedOptions = [];
    }

    toggle(item: any) : void {
        var idx = this.selectedOptions.indexOf(item);
        if (idx > -1) {
            this.selectedOptions.splice(idx, 1);
        }
        else {
            this.selectedOptions.push(item);
        }
    };

    exists(item: any) : boolean {
        return this.selectedOptions.indexOf(item) > -1;
    };

    isIndeterminate() : boolean {
        return this.selectedOptions.length !== 0 &&
            this.selectedOptions.length !== this.availableOptions.length;
    }

    isChecked() : boolean {
        return this.selectedOptions.length === this.availableOptions.length;
    };

    toggleAll() : void {
        if (this.isChecked()) {
            this.selectedOptions = [];
        } else {
            this.selectedOptions = this.availableOptions.slice(0);
        }
    };
}
