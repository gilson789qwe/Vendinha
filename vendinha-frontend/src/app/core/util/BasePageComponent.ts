export class BasePageComponent {
  paginate = {
    page: 0,
    total: 0,
    linesPerPage: 10,
    pageNumber: 1
  };
  domainId: any = '';

  prepareType(type: string) {
    if (type == 'first') {
      this.paginate.page = 0;
      this.paginate.pageNumber = 1;
    }
    else if (type == 'prev') {
      this.paginate.page = this.paginate.page - this.paginate.linesPerPage;
      this.paginate.pageNumber = this.paginate.pageNumber - 1;
    }
    else if (type == 'next') {
      this.paginate.page = this.paginate.page + this.paginate.linesPerPage;
      this.paginate.pageNumber = this.paginate.pageNumber + 1;
    }
    else if (type == 'last') {
      this.paginate.page = this.paginate.total - this.paginate.linesPerPage;
      let temp = Math.ceil(this.paginate.total / this.paginate.linesPerPage);
      this.paginate.pageNumber = temp;
    }
  }

  isLastPage(): boolean {
    return this.paginate.total === Math.min(this.paginate.total, (this.paginate.page + this.paginate.linesPerPage));
  }

  isFirstPage(): boolean {
    return this.paginate.page === 0;
  }

  isPaginate(): boolean {
    return this.paginate.total > this.paginate.linesPerPage;
  }

  next() {
    this.paginate.page = this.paginate.page + this.paginate.linesPerPage;
  }

  prev() {
    this.paginate.page = this.paginate.page - this.paginate.linesPerPage;
  }

  updateUrl(event: { target: { src: string; }; }) {
    event.target.src = "assets/images/files/image.svg";
  }

  setCursorMoney(el: { target: { selectionStart: number; selectionEnd: number; }; }) {
    setTimeout(function () {
      el.target.selectionStart = 3;
      el.target.selectionEnd = 3;
    }, 200);
  }
  get currentPage() {
    return Math.min(this.paginate.linesPerPage + this.paginate.page, this.paginate.total)
  }
}