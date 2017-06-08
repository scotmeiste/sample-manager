import { Component, OnInit } from '@angular/core';
import { SamplesService } from '../../services/samples.service';
import { Sample } from '../../models/sample';
import { statuses } from '../../models/status';

@Component({
  selector: 'app-samples-status',
  templateUrl: './samples-status.component.html',
  styleUrls: ['./samples-status.component.css']
})
export class SamplesStatusComponent implements OnInit {
  private samples: Sample[];
  private statusId: number;

  private statuses = statuses;

  constructor(private samplesService: SamplesService ) { }

  ngOnInit() {
  }

  getSamples() {
    this.samplesService.getSamplesByStatus(this.statusId)
      .then( samples => {
        this.samples = samples;
      });
  }

}
