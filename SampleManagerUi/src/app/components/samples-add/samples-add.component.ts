import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SamplesService } from '../../services/samples.service';
import { Sample } from '../../models/sample';
import { statuses } from '../../models/status';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-samples-add',
  templateUrl: './samples-add.component.html',
  styleUrls: ['./samples-add.component.css']
})
export class SamplesAddComponent implements OnInit {
  private statuses = statuses;
  private users: User[];
  private sample: Sample;
  private showError = false;
  
  constructor(private samplesService: SamplesService, private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.getUsers()
      .then(users => {this.users = users;});

    this.sample = new Sample();
  }

  save() {
    this.samplesService.saveSample(this.sample)
      .then(result => {
        if (result) {
          this.router.navigate(['/samples/all'])
        } else {
          this.showError = true;
        }
      })
      .catch(err => {this.showError = true;});
  }

  cancel() {
    this.router.navigate(['/samples/all'])
  }
}
