import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-spells',
  templateUrl: './spells.component.html',
  styleUrls: ['./spells.component.scss']
})

export class SpellsComponent implements OnInit {

  private spells: Object;

  constructor(private data: DataService) { }

  ngOnInit() {
    this.data.getSpells().subscribe(data => {
      this.spells = data;
      console.log(this.spells);
    })
  }

}
