import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

  private spells: Object;

  constructor(private data: DataService) { }

  ngOnInit() {
    this.data.getSpells().subscribe(data => {
      this.spells = data[0];
      console.log(this.spells);
    });
  }
}
