import { Component, OnInit } from "@angular/core";
import { User } from "src/app/_models/user";
import { UserService } from "src/app/_services/user.service";
import { AlertifyService } from "src/app/_services/alertify.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-member-detail",
  templateUrl: "./member-detail.component.html",
  styleUrls: ["./member-detail.component.css"]
})
export class MemberDetailComponent implements OnInit {
  user: User;

  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private route: ActivatedRoute // s  tem dobimo dostop do URL in z njim id za user
  ) {}

  ngOnInit() {
    this.loadUser();
  }

  // id dobimo iz urlja: members/4
  loadUser() {
    this.userService.getUser(+this.route.snapshot.params["id"]).subscribe(
      //+ znak pomeni da se bo id iz URL na silo prebral kot integer
      (user: User) => {
        this.user = user;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
