import { NextResponse } from 'next/server'
import type { NextRequest } from 'next/server'

import links from '~packages/links'
import { ACCESS_TOKEN_NAME } from '~packages/system'

export default function middleware(req: NextRequest) {
	const redirect = (str: string) =>
		NextResponse.redirect(new URL(str, req.url))

	const isAuth = req.cookies.has(ACCESS_TOKEN_NAME)

	const guestLinks = [links.login, links.register]

	const isGuestLinks = guestLinks.includes(req.nextUrl.pathname)

	if (isGuestLinks && isAuth) {
		return redirect(links.actors.index)
	}

	if (!isGuestLinks && !isAuth) {
		return redirect(links.login)
	}

	return NextResponse.next()
}

export const config = { matcher: '/((?!.*\\.).*)' }
