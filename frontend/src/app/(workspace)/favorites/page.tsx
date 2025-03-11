'use client'

import BooksFavorites from '~widgets/books-favorites'

import { BreadcrumbsTitle } from '~packages/ui'

export default function FavoritesPage() {
	return (
		<>
			<BreadcrumbsTitle title={'Избранные книги'} />
			<BooksFavorites />
		</>
	)
}
