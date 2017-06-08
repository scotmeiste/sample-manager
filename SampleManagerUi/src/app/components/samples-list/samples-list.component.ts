import { Component, OnInit, Input } from '@angular/core';
import { Sample } from "../../models/sample";

@Component({
  selector: 'samples-list',
  templateUrl: './samples-list.component.html',
  styleUrls: ['./samples-list.component.css']
})
export class SamplesListComponent implements OnInit {
  @Input() samples: Sample[];

  constructor() { }

  ngOnInit() {
  }

}
