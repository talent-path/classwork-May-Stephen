import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login.component';
import { CardDetailComponent } from './card-detail/card-detail.component';
import { CardListComponent } from './card-list/card-list.component';
import { SeriesListComponent } from './series-list/series-list.component';

const accountModule = () => import('./account/account.module').then(x => x.AccountModule);


const routes: Routes = [{path: "cardDetails/:id", component: CardDetailComponent},
{path: "set/:id", component: CardListComponent},
{path: "allSets", component: SeriesListComponent},
{path: "account", loadChildren: accountModule}]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}