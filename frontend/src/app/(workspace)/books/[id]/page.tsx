'use client'

import { use } from 'react'

import BookOverview, {
	BookOverviewAbout,
	BookOverviewCategories,
	BookOverviewTags,
} from '~widgets/book-overview'

import { IBook, useBook } from '~models/book'

import { RenderFetchData } from '~packages/lib'
import { Spacing } from '~packages/ui'

import BookLoading from './loading'

export default function BookPage({
	params,
}: {
	params: Promise<{ id: string }>
}) {
	const { id } = use(params)
	const { isLoading, data } = useBook(id)

	return (
		<>
			<RenderFetchData
				isLoading={isLoading}
				loadingFallback={<BookLoading />}
			>
				<BookOverview book={data?.data.result as IBook}>
					<BookOverviewAbout book={data?.data.result as IBook} />
					<Spacing />
					<BookOverviewCategories book={data?.data.result as IBook} />
					<Spacing />
					<BookOverviewTags book={data?.data.result as IBook} />
				</BookOverview>
			</RenderFetchData>
		</>
	)
}
