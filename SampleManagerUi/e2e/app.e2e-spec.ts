import { SampleManagerUiPage } from './app.po';

describe('sample-manager-ui App', () => {
  let page: SampleManagerUiPage;

  beforeEach(() => {
    page = new SampleManagerUiPage();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
