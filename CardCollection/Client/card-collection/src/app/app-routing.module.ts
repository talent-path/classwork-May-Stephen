import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardDetailComponent } from './card-detail/card-detail.component';
import { CardListComponent } from './card-list/card-list.component';
import { SeriesListComponent } from './series-list/series-list.component';

const routes: Routes = [{path: "cardDetails", component: CardDetailComponent},
{path: "set/:id", component: CardListComponent},
{path: "allSets", component: SeriesListComponent}]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}