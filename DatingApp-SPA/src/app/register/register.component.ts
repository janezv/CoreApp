import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancleRegister = new EventEmitter();
  model: any = {};

  constructor( private authServic: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authServic.register(this.model).subscribe(()=> {
        console.log("registration successful");
      }, error => {
        console.log(error);
      }
    )};

  cancel() {
    this.cancleRegister.emit(false);
    console.log('Cancelled');
  }

}
