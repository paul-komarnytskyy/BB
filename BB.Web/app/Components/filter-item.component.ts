import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'filter-item',
    templateUrl: './filter-item.html',
    inputs: ['availableOptions:init', 'name:init', 'id:init']
})

export class FilterItemComponent {
    @Input() availableOptions: any[];
    @Input() name: string;
    @Input() id: string;

    public selectedOptions: any[];

    @Output()
    change: EventEmitter<any> = new EventEmitter<any>();

    constructor() {
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

        var emittedObject = { CharacteristicId: this.id, Name: this.name, Options: this.selectedOptions };
        this.change.emit(emittedObject)
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
