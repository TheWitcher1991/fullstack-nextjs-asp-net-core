import { BookFlexCard, IBook } from '~models/book'

interface BookListProps {
	books: IBook[]
}

export default function BookList({ books }: BookListProps) {
	return books.map(relax => <BookFlexCard key={relax.id} book={relax} />)
}
