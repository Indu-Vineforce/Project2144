import { Project2144TemplatePage } from './app.po';

describe('Project2144 App', function () {
    let page: Project2144TemplatePage;

    beforeEach(() => {
        page = new Project2144TemplatePage();
    });

    it('should display message saying app works', () => {
        page.navigateTo();
        expect(page.getParagraphText()).toEqual('app works!');
    });
});
