import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { MemberListComponent } from "./member-list/member-list.component";
import { MessagesComponent } from "./messages/messages.component";
import { ListsComponent } from "./lists/lists.component";
import { AuthGuard } from "./_guards/auth.guard";

//filozofija prednosti je ista kot pri MVCju, router gre brati od zgoraj navzdol kje se URL ujema
export const appRoutes: Routes = [
  { path: "", component: HomeComponent }, //home link ki ima prazen URL za strežnikom
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      { path: "members", component: MemberListComponent },
      { path: "messages", component: MessagesComponent },
      { path: "lists", component: ListsComponent }
    ]
  },
  { path: "**", redirectTo: "", pathMatch: "full" } // če je domain URL okej in je nato karkoli, preusmeri na homecomponent
];
