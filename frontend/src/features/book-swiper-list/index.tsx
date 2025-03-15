import { Swiper, SwiperSlide } from 'swiper/react'

import { BookCard, IBook } from '~models/book'

import 'swiper/swiper-bundle.css'

interface BookSwiperListProps {
	books: IBook[]
	spaceBetween?: number
	slidesPerView?: number
}

export default function BookSwiperList({
	books,
	spaceBetween,
	slidesPerView,
}: BookSwiperListProps) {
	return (
		<Swiper
			spaceBetween={spaceBetween || 8}
			slidesPerView={slidesPerView || 7}
		>
			{books.map(book => (
				<SwiperSlide key={book.id}>
					<BookCard book={book} />
				</SwiperSlide>
			))}
		</Swiper>
	)
}
